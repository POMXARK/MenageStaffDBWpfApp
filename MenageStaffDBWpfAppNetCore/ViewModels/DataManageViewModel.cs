using MenageStaffDBWpfAppNetCore.Data.Repositories;
using MenageStaffDBWpfAppNetCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenageStaffDBWpfAppNetCore.ViewModels
{
    public class DataManageViewModel: BaseViewModel
    {
        // все отделы
        private List<Department> _departments = DataWorkerRepository.GetDepartments();
        public List<Department> AllDepartments
        {
            get { return _departments; }
            set { 
                _departments = value;
                NotifyPropertyChanged("AllDepartments");
            }
        }

        //все позиции
        private List<Position> _positions = DataWorkerRepository.GetPositions();
        public List<Position> AllPositions
        {
            get
            {
                return _positions;
            }
            private set
            {
                _positions = value;
                NotifyPropertyChanged("AllPositions");
            }
        }

        //все сотрудники
        private List<User> _users = DataWorkerRepository.GetUsers();
        public List<User> AllUsers
        {
            get
            {
                return _users;
            }
            private set
            {
                _users = value;
                NotifyPropertyChanged("AllUsers");
            }
        }
    } 
}
