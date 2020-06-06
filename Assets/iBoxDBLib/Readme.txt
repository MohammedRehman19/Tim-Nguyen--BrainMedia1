
iBoxDB is an Embedded NoSQL Database, has an intuitive API,
everything is inside the code, no DBMS required.

Features:
  CRUD
  KeyValue and KeyOnly tables
  Unique and non-unique indexes
  Unique and non-unique composite indexes
  SQL like query language
  Transactions support
  Concurrency control, thread safe
  Memory management
  Scalable hot MasterSlave and MasterMaster replications
  On disk and in memory databases supported
  Automatically create databases
  Zero configuration, copy and run, purely managed code
  Dynamic columns
  Different types with different indexes can be stored in same table
  Persistence + ORM + Cache + Embeddable, ONE STOP solution
  High performance, no dependencies
  Update Increment
  Selecting Tracer
  Snapshot-Serializable Isolation

Please visit WebSite(http://www.iboxdb.com) for more updated information.



Usage:
it is easy to use.

//set db path
DB.Root (Application.persistentDataPath);

//create a DB
DB db = new DB();

//Create Table(Player) with Key(ID)
db.GetConfig().EnsureTable<Player>("Player", "ID");

//open database for CRUD operations
AutoBox auto = db.Open ();

//CRUD methods
Insert()/Select()/Update()/Delete()

Example:
UnityDBCS.cs

Build and Run:
Player Settings -> Api Compatibility Level -> .NET2.0/.NET4.0/.NetStandard2.0. (not Subset) 
Player Settings -> Stripping Level -> Strip Byte Code.
