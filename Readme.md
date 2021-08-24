<!-- Part 1 -->
# Part 1

Indg Exchange has tree end poins for Users, Items and Item transactions. The ownership relation is 1:n between users and items. 
Item transactons is used to transfer items between users. Also individual ownership assignments can be made to items.
Core and Data projects form the Infrastructure layer. Domain Layer is mostly used for architectural design and definitions.
The transfers between users are transactional that is why I decided to use strategy pattern while developing write services. That said read and write service are also
separated to accept queries and commands. It may not be a full fledged CQRS but should ease the load on data layer caused by transactions.

### Users Endpoint
This endpoint is used for standard CRUD operations to User entities. Since ownership ise stored on items
there was noo need to use transactional write strategies so it uses basic repository methods

### Items Endpoint
This endpoint is used for standard CRUD operations to Item entities. Item creations and updates are transactional.
To demonstrate why I have used the strategy patter you can check there is two item update strategies in the
project. Changing the injection settings in settings will change how the items are updated

### Item Transactions Endpoint

