using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace aaaa {

    class Worker {
        public string LastName { set; get; }
        public uint age;
        public ObservableCollection<Project> Projects = new ObservableCollection<Project>();

        public Worker(string LastName, uint age, ObservableCollection<Project> Projects) {
            this.LastName = LastName;
            this.age = age;
            this.Projects = Projects;

        }

    }
    class Project {
        public string Name { set; get; }

        public DateTime DateOfStart;

        public Project(string Name, DateTime DateOfStart) {
            this.Name = Name;
            this.DateOfStart = DateOfStart;
        }

        public Project(string Name) {
            this.Name = Name;
            this.DateOfStart = System.DateTime.Now;
        }

        public ObservableCollection<Worker> Workers = new ObservableCollection<Worker>();

    }


    class IT_Company {
        string Name { set; get; }
        ObservableCollection<Worker> Workers = new ObservableCollection<Worker>();
        ObservableCollection<Project> Projects = new ObservableCollection<Project>();

        public IT_Company(string Name) {
            this.Name = Name;
        }

        //Выборка Работников у которых больше 2-х проектов и им меньше 30
        public IOrderedEnumerable<Worker> WorkersLess30More2Pr() {
            return from w in Workers
                   where (w.age < 30 || w.Projects.Count() >= 2)
                   orderby w.LastName descending, w.age
                   select w;
        }

        //Выборка проектов начиная c определенной даты 
        public IOrderedEnumerable<Project> ProjectAfterDate(DateTime date) {
            return from p in Projects
                   where p.DateOfStart <= date
                   orderby p.DateOfStart
                   select p;
        }

        //Выборка проектов которые стартавали не более 2-х лет назад + сотрудникам меньше 30
        public int ProjectLess2Less30() {
            return (from p in Projects
                    where (p.DateOfStart.Year - System.DateTime.Now.Year < 1 || (from w in p.Workers
                                                                                 where w.age >= 30
                                                                                 select w).Count() == 0)
                    select p).Count();
        }

        //Фамилия самого старого сотрудника с одним проектом
        public string Method4() {
            return (from w in Workers
                    where (w.Projects.Count() == 1 || w.Projects.First().DateOfStart.Year == System.DateTime.Now.Year)
                    orderby w.age
                    select w).First().LastName;
        }

    }

    class Program {
        static void Main(string[] args) {

        }
    }
}
