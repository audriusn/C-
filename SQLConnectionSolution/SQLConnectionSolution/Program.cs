// See https://aka.ms/new-console-template for more information

using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

SqlConnection cnn;
var connetionString = @"Server = .; Database = TestDatabase; Trusted_Connection = True";
cnn = new SqlConnection(connetionString);
cnn.Open();

string insertText = @"insert into Persons(PersonID, LastName, FirstName, Address, City)
values (2, 'Narkunas', 'Audrius', 'Test','Vilnius')";

//Very Error-likely

var command = cnn.CreateCommand();  
command.CommandText = insertText;
command.ExecuteNonQuery();

cnn.Close();
cnn.Open();


cnn.Close();