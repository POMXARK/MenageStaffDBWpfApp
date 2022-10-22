using MenageStaffDBWpfAppNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace MenageStaffDBWpfAppNetCore.Data.Repositories
{
    /// <summary>
    /// using мы используем, потому что нужно высвобождать ресурсы от созданного объекта. 
    /// Этот оператор освобождает от использования методов close и dispose
    /// </summary>
    public static class DataWorkerRepository
    {
        // получить все отделы
        public static List<Department> GetDepartments()
        {
            List<Department> result = null;

            using (ApplicationContext context = new ApplicationContext())
            {
                result = context.Departments.ToList();
            }

            return result;
        }


        // получить все позиции
        public static List<Position> GetPositions()
        {
            List<Position> result = null;

            using (ApplicationContext context = new ApplicationContext())
            {
                result = context.Positions.ToList();
            }

            return result;
        }

        // получить всех сотрудников
        public static List<User> GetUsers()
        {
            List<User> result = null;

            using (ApplicationContext context = new ApplicationContext())
            {
                result = context.Users.ToList();
            }

            return result;
        }

        //создать отдел
        public static string CreateDepartment(string name)
        {
            string result = "Уже существует";
            using (ApplicationContext context = new ApplicationContext())
            {
                // проверяем существует ли отдел
                bool checkIsExist = context.Departments.Any(el => el.Name == name);

                if (!checkIsExist)
                {
                    var newDepartment = new Department { Name = name }; // инициализатор
                    context.Departments.Add(newDepartment);
                    context.SaveChanges();
                    result = "Сделанно";
                }

                // return result;
                // return надо делать за областью видимости using,
                // иначе программа не дойдет до конца блока кода "using" и не выполнит  close и dispose для созданного объекта.
                // Такими действиями свели на ноль смысл использования оператора using
            }

            return result;
        }

        // создать позицию
        public static string CreatePosition(string name, decimal selary, int maxNumber, Department department)
        {
            string result = "Уже существует";
            using (ApplicationContext context = new ApplicationContext())
            {
                // проверяем существует ли позиция
                bool checkIsExist = context.Positions.Any(el => el.Name == name && el.Selary == selary);

                if (!checkIsExist)
                {
                    var newPosition = new Position
                    {
                        Name = name,
                        Selary = selary,
                        MaxNumber = maxNumber,
                        DepartmentId = department.Id
                    };

                    context.Positions.Add(newPosition);
                    context.SaveChanges();
                    result = "Сделанно";
                }
            }

            return result;
        }

        // создать сотрудника
        public static string CreateUser(string name, string surName, string phone, Position position)
        {
            string result = "Уже существует";
            using (ApplicationContext context = new ApplicationContext())
            {
                // проверяем существует ли пользователь
                bool checkIsExist = context.Users.Any(el => el.Name == name && el.SurName == surName && el.Position == position);

                if (!checkIsExist)
                {
                    var newUser = new User
                    {
                        Name = name,
                        SurName = surName,
                        Position = position,
                        PositionId = position.Id
                    };

                    context.Users.Add(newUser);
                    context.SaveChanges();
                    result = "Сделанно";
                }
            }

            return result;
        }

        // удалить отдел
        public static string DeleteDepartment(Department department)
        {
            string result = "Такого отдела не существует";
            using(ApplicationContext context = new ApplicationContext())
            {
                context.Departments.Remove(department);
                context.SaveChanges();
                result = "Сделано! Отдел" + department.Name + " удален!";
            }

            return result;
        }

        // удалить позицию
        public static string DeletePosition(Position position)
        {
            string result = "Такой позиции не существует";
            using (ApplicationContext context = new ApplicationContext())
            {
                context.Positions.Remove(position);
                context.SaveChanges();
                result = "Сделано! Позиция" + position.Name + " удалена!";
            }

            return result;
        }

        // удалить сотрудника
        public static string DeleteUser(User user)
        {
            string result = "Такого cотрудника не существует";
            using (ApplicationContext context = new ApplicationContext())
            {
                context.Users.Remove(user);
                context.SaveChanges();
                result = "Сделано! Сотрудник" + user.Name + " уволен!";
            }

            return result;
        }

        // редактировать отдел
        public static string EditDepartment(Department oldDepartment, string newName)
        {
            string result = "Такого отдела не существует";
            using (ApplicationContext context = new ApplicationContext())
            {
                var department = context.Departments.FirstOrDefault(d => d.Id == oldDepartment.Id);
                department.Name = newName;
                context.SaveChanges();
                result = "Сделано! Отдел" + department.Name + " изменен!";
            }

            return result;
        }

        // редактировать позицию
        public static string EditPosition(Position oldPosition, string newName, int newMaxNumber, decimal newSelary, Department newDepartment)
        {
            string result = "Такой позиции не существует";
            using (ApplicationContext context = new ApplicationContext())
            {
                var position = context.Positions.FirstOrDefault(p => p.Id == oldPosition.Id);
                position.Name = newName;
                position.Selary = newSelary;
                position.MaxNumber = newMaxNumber;
                position.DepartmentId = newDepartment.Id;
                context.SaveChanges();
                result = "Сделано! Позиция" + position.Name + " изменена!";
            }

            return result;
        }

        // редактировать сотрудника
        public static string EditUser(User oldUser, string newName, string newSurName, string newPhone, Position newPosition)
        {
            string result = "Такого cотрудника не существует";
            using (ApplicationContext context = new ApplicationContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Id == oldUser.Id);
                if(user != null)
                {
                    user.Name = newName;
                    user.SurName = newSurName;
                    user.Phone = newPhone;
                    user.PositionId = newPosition.Id;
                    context.SaveChanges();
                    result = "Сделано! Сотрудник" + user.Name + " уволен!";
                }
            }

            return result;
        }
    }
}
