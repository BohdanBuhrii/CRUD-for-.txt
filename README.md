# CRUD-for-.txt
CRUD (create, read, update, delete) logic realization using .txt files instead of database 

----<Short review>----
Contains three classes:

TextConnection - Can manipulate with tables in textbase. Contains path to .txt file (textbase). 

TextDataReader - Can read table using name and TextConnection. Implements IDisposable interface

Table - Using for manipulate with concrete table (create, read, update and delete objects (rows)), needs table name and TextConnection

