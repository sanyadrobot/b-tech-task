# task description

Implement a working version of a store with domain isolation in Unity.
Particular attention to the code and its structure. Organizing assets in Unity is secondary.
You need to make a simple screen (scene) with a showcase of a game “store”:
The player sees a list of bundles that he can buy.
Each bundle has a name and a “Buy” button.
If the player does not have enough resources to purchase, the “Buy” button is inactive.
Bundles should be configured by game designers through the inspector in Unity (in ScriptableObject).
The cost and reward for the bundle should be configured very flexibly, by combining the “building blocks” provided by the programmers.
The cost and reward for the bundle are not visible, so as not to complicate the task.
We want us to have a conditional domain model, when the code has many domains (separate folders) and they do not know anything about each other, and have general knowledge only through the Kernel. For example, there is a health domain, where all the business logic associated with lives is carried out. The location domain where the behavior on which map the player is located is processed. And others.
Moreover, a store is also a domain that should not know anything about other parallel domains.
We agree that the appearance of a new brick for setting rewards and costs occurs within each domain separately. Those. if lives must be spent to purchase a bundle, then the “brick” of spending lives should lie in the health domain (folder). And if, as a reward, we want to move the player to another location, then the “brick” of the reward that moves to the location must be in the domain (folder) of locations.
We agree that the concepts that something can be spent or issued are in the Core, i.e. All domains know about them. But at the same time, they are as laconic and abstract as possible, so as not to refer us to the understanding that there is a store in higher-level domains.
Technical introduction:
There are 5 domains:
Core - the core, here are ISpendable and IReward - interfaces that should express that something can be spent and rewarded. Deciding what these interfaces should look like is part of the challenge. Usually, there shouldn't be anything other than these interfaces here. Simple utilitarian things are allowed, for example, a single singleton implementation.
Health is a domain responsible for health, we believe that health is available globally through the HealthManage.Instance singleton.
Gold is the domain responsible for gold, we believe that gold is available globally through the GoldManage.Instance singleton.
Location - the domain responsible for the player’s current location; we assume that the location is available globally through the LocationManager.Instance singleton. Moreover, the location is a purely textual value, i.e. some conventional name of the current location. There is no need to create any classes describing the type of location.
Shop - the domain responsible for the store.
Domains are assembly folders (with nested .asmdefs), while the Health, Gold, Location and Shop assemblies have dependencies on Core, and do not have dependencies on each other.
All project code must be located strictly in these domains; no other domains or folders with code are allowed.
Within domain folders, the code is organized so that one class or interface is one file.
We agree that in Unity it is possible to use reflection in the inspector. Those. if we have a field:
[SerializeReference] private IInterface Field;
And there are classes that implement IInterface.
Then the Field field will appear in the Unity Inspector, which will have a “dropdown” with the ability to select an instance of which class (inheriting IInterface) should be created and assigned to this field.
For example, Odin implements it like this:

If you don’t have access to Odin, you can write your own PropertyDrawer, or use a ready-made solution
https://github.com/medvedya/Select-implementation-property-drawer
The store's assortment should be flexibly configured via ScriptableObject. The store consists of bundles, where each bundle can have any price and any reward.
The following “cubes” for spending and rewards should be implemented (implementations of ISpendable and IReward):
fixed amount of gold;
fixed amount of health;
percentage of health from the current one;
changing the current location to the specified one (in text).
We need a simple GUI that displays bundle cards in a row, where each card is: a large inscription with the name of the bundle and a “buy” button, and the buy button is inactive if the player does not have enough resources. There is no need to display the price or reward.
Somewhere right there in the GUI it is displayed:
current amount of gold
current amount of health
current location
no graphic frills.
The business logic for each entity from the point above must be implemented strictly in its own domain. Those. each domain is completely isolated. This means that there should be nothing in Core that could be centrally responsible for the player's resources. And also there should not be some very high domain like GUI.
In the GUI, next to each displayed current amount of resource from the points above (current health, current gold, current location) there should be a “+” button, which, like a cheat, increases the current amount accordingly