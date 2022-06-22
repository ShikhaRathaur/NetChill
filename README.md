
## Installation and setup of the project:

  
1)Navigate to ClientApp Folder to Install Dependencies
``` bash
npm install
```
2)Define SQL server Credentials in appsetting .json
  
3)Create 'superuser' role inside database table using below Link;
  [URL](https://localhost:44377/administration/createrole)

4)Signup and create admin with name 'netchill_admin' and with any 
email and secure password.

5)id(adminid/userid) from table [AspNetUsers] ,
Id{Roleid} from [AspNetUserRoles] needs to be taken
for insert query operation.The sole purpose of doing this is to distinguish admin as a superuser.


Write this query:


``` bash

INSERT INTO [dbo].[AspNetUserRoles]
           ([UserId]
           ,[RoleId])
     VALUES
           (<UserId, nvarchar(450),>
           ,<RoleId, nvarchar(450),>)
GO
```
6)Run the Application



    