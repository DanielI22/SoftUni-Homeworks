using System.Data.SqlClient;

SqlConnection connection = new SqlConnection("Server=.\\SQLEXPRESS;Database=SoftUni;Trusted_Connection=True;");
Console.WriteLine("TEST");
connection.Open();
using(connection)
{
    SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Employees", connection);
    int employeesCount = (int)command.ExecuteScalar();
    Console.WriteLine(employeesCount);
}

