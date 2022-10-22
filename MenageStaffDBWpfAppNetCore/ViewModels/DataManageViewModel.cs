using MenageStaffDBWpfAppNetCore.Commands;
using MenageStaffDBWpfAppNetCore.Data.Repositories;
using MenageStaffDBWpfAppNetCore.Models;
using MenageStaffDBWpfAppNetCore.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

        #region COMMANDS TO OPEN WINDOWS
        private RelayCommand openAddNewDepartmentWnd;
        public RelayCommand OpenAddNewDepartmentWnd
        {
            get
            {
                return openAddNewDepartmentWnd ?? new RelayCommand(obj =>
                {
                    OpenAddDepartmentWindowMethod();
                }
                    );
            }
        }
        private RelayCommand openAddNewPositionWnd;
        public RelayCommand OpenAddNewPositionWnd
        {
            get
            {
                return openAddNewPositionWnd ?? new RelayCommand(obj =>
                {
                    OpenAddPositionWindowMethod();
                }
                );
            }
        }
        private RelayCommand openAddNewUserWnd;
        public RelayCommand OpenAddNewUserWnd
        {
            get
            {
                return openAddNewUserWnd ?? new RelayCommand(obj =>
                {
                    OpenAddUserWindowMethod();
                }
                );
            }
        }
        #endregion

        #region METHODS TO OPEN WINDOW
        //методы открытия окон
        private void OpenAddDepartmentWindowMethod()
        {
            AddNewDepartmentWindow newDepartmentWindow = new AddNewDepartmentWindow();
            SetCenterPositionAndOpen(newDepartmentWindow);
        }
        private void OpenAddPositionWindowMethod()
        {
            AddNewPositionWindow newPositionWindow = new AddNewPositionWindow();
            SetCenterPositionAndOpen(newPositionWindow);
        }
        private void OpenAddUserWindowMethod()
        {
            AddNewUserWindow newUserWindow = new AddNewUserWindow();
            SetCenterPositionAndOpen(newUserWindow);
        }

        //окна редактирования
        private void OpenEditDepartmentWindowMethod(Department department)
        {
            EditDepartmentWindow editDepartmentWindow = new EditDepartmentWindow();
            SetCenterPositionAndOpen(editDepartmentWindow);
        }
        private void OpenEditPositionWindowMethod(Position position)
        {
            EditPositionWindow editPositionWindow = new EditPositionWindow();
            SetCenterPositionAndOpen(editPositionWindow);
        }
        private void OpenEditUserWindowMethod(User user)
        {
            EditUserWindow editUserWindow = new EditUserWindow();
            SetCenterPositionAndOpen(editUserWindow);
        }

        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }
        #endregion
    }
}
