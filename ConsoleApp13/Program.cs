using System;

using System.Data;
using System.Data.SqlClient;


namespace proj
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = @"Data source=WIN-5RSC18PG333\SQLEXPRESS; initial catalog=project; Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);



            connection.Open();
            //string sqlinfo = $"insert into Person([Firstname],[lastname],[middle name], [date of birth]) values ('hj', 'Teshaev', 'Akramovich', '2018-01-05')";
            if (connection.State == ConnectionState.Open)
            {
                

                Console.WriteLine("Connected Successfuly ");
            }
            int numb;
            Console.WriteLine("Введите число: \n1 -> Insert (Добавление) \n2 -> Select All(Выбрать всё) \n3 -> Select by Id (Выбрать один по Id) \n4 -> Update (Обновить каждый столбец кроме Id) \n5 -> Delete (Удалить один по Id)");
            numb = Convert.ToInt32(Console.ReadLine());
            SqlCommand command = connection.CreateCommand();
            if (numb == 1)
            {
                Console.Write("Name = ");
                string Name = Console.ReadLine();
                Console.Write("Surname = ");
                string Surname = Console.ReadLine();
                Console.Write("MiddleName = ");
                string MiddleName = Console.ReadLine();
                Console.Write("DateofBirth = ");
                string DateofBirth = Console.ReadLine();
                command.CommandText= $"Insert into Person ([Name],[Surname],[MiddleName], [DateofBirth]) values ('{Name}', '{Surname}', '{MiddleName}', '{DateofBirth}')";
                var result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("The person is added!");
                }





                
                



            }

            if (numb == 2)
            {
                command.CommandText = "Select * from Person";
                var reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, Surname: {reader["Surname"]}, Middle Name: {reader["MiddleName"]}, DateofBirth{reader["DateofBirth"]}");
                }

            }
            if (numb == 3)
            {
                int id;
                Console.WriteLine("Введите ID человека от 2 до 5 ");
                id = Convert.ToInt32(Console.ReadLine());
                command.CommandText = $"Select *from Person where Id = {id}";

                var reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, Surname: {reader["Surname"]}, MiddleName: {reader["MiddleName"]}, Date of Birth{reader["DateofBirth"]}");
                }

            }
            if (numb == 4)
            {
                int idnum = 0;
                Console.WriteLine("Введите ID = ");
                idnum = Convert.ToInt32(Console.ReadLine());

                string updatename;
                Console.WriteLine("Введите новое имя = ");
                updatename = Console.ReadLine();
                string updatesurname;
                Console.WriteLine("Введите новую фамилию = ");
                updatesurname = Console.ReadLine();
                string updatemiddlename;
                Console.WriteLine("Введите новое отчество = ");
                updatemiddlename = Console.ReadLine();
                string updatedateofbirth;
                Console.WriteLine("Введите новую дату рождения = ");
                updatedateofbirth = Console.ReadLine();
                command.CommandText = "update person set " + "Name = " + $"'{updatename}'," + "Surname = " + $"'{updatesurname}'," + "MiddleName = " + $"'{updatemiddlename}'," + "DateofBirth = " + $"'{updatedateofbirth} '" + "where Id = " + $"'{idnum}'";

                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    Console.WriteLine("Seccessfully uploaded information!");
                }
                //update = Convert.ToInt32(Console.ReadLine());
                var reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, Surname: {reader["Surname"]}, MiddleName: {reader["MiddleName"]}, Date of Birth{reader["DateofBirth"]}");
                } 

                 
            }
            if (numb == 5)
            {
                int id;
                Console.WriteLine("Введите ID человека которого вы желаете удалить = ");
                id = Convert.ToInt32(Console.ReadLine());
                command.CommandText = $"Delete Person where Id = {id}";
                int result1 = command.ExecuteNonQuery();
                if (result1 > 0)
                {
                    Console.WriteLine("Seccessfully deleted the person under ID = " + id);
                }

            }
        }
    }
}
