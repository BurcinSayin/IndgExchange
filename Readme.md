<!-- Part 1 -->
# Part 1

Indg Exchange has tree end poins for Users, Items and Item transactions. The ownership relation is 1:n between users and items. 
Item transactons is used to transfer items between users. Also individual ownership assignments can be made to items.
Core and Data projects form the Infrastructure layer. Domain Layer is mostly used for architectural design and definitions. Data layer 
uses EF Core and SqLite, both can be thanks to repositories.The transfers between users are transactional that is why I 
decided to use strategy pattern while developing write services. That said read and write service are also
separated to accept queries and commands. It may not be a full fledged CQRS but should ease the load on data layer caused by transactions.

### Users Endpoint
This endpoint is used for standard CRUD operations to User entities. Since ownership ise stored on items
there was noo need to use transactional write strategies so it uses basic repository methods

### Items Endpoint
This endpoint is used for standard CRUD operations to Item entities. Item creations and updates are transactional.
To demonstrate why I have used the strategy patter you can check there is two item update strategies in the
project. Changing the injection settings in settings will change how the items are updated

### Item Transactions Endpoint
This endpoint is used to make item exchanges. this can be 2 way or 1 way item exchange. a 1 way exhange example is 
when a item owned by no one is taken by somebody. 2 way exchanges are like simple barter. Each transaction record
should have a TakenItemId and TakingUserId (for at leas 1 way ownership change)

### Token Endpoint
This is a very simple authentication end point that will give you jwt tokens. Tokens have a lifetime of 5 days wich too 
long to use in a real system. On swagger you can add the auth token header from the top right corner from the UI
Please remember adding "Bearer " to the start of the authentication header. For testing purposes a hardcoded user pass
is present ( username:admin pass:admin ). Event there is no user present this ( admin/admin ) should generate a 
valid jwt token. Otherwise  existing username pass values are checked.

### Some Questions about Part 1
#### Why Strategy pattern ?
When used with transactions I think this can give us more flexibility doing write operations. We even be able use NoSql
repositories.   
#### Why user repositories while using EF ?
To make EF replaceable. If we want to sue some other data provider we can easily do so
by implementing repositories for that provider. 
#### Why do we have our own Transaction wrapper ?
Not all data providers have the same logic for managing transactions. Since our app focuses on transaction we cau use it 
to use those different kinds ow transactions with less code change
#### Why separate queries and commands
Transactions are very expensive operations by doing this we can read without locking data
improving performance


# Part 2

I used Azure as cloud platform. There is one app service running. Azure CI/CD pipeline is used with a build agent connected to
azure because Azure hosted build servers were not available. To manage deployment resources terraform is used 
whose resource state is stored in an Azure blob storage.

A push to main branch. Performs the actions below:

    * Pull main branch.
    * Restore dependencies
    * Build
    * Run Tests
    * Publish Symbol Paths
    * Copy terraform config file into deploy artifacts 
    * Publish artifact 
    * Terraform actions ( state is stored on a blob in azure so that we can redeploy withou recreating same resources)
        * Creates resource group
        * Generates an app service plan
        * Creates app service running using created plan. 
    * Publish Indg Exchage API

## App url
https://indgexchange-appservice.azurewebsites.net/swagger/

####For Testing
* Create a token with usr:admin pass:admin
* Create an item (i.e. ID: 1)
* Create an user (i.e. ID: 5)
* update item to change owner OR create 1 way transaction (i.e. takenItemId:1 takingUserId:5)
* Create another user (i.e. ID: 21)
* Create another item with owner (ID: 2 with owner 21)
* Exchange Items (i.e. takenItemId: 1,givingUserId: 5,exchangedItemId: 2,takingUserId: 21)