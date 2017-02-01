
using System;
using Prenotes.Services.Things;

namespace Prenotes.Services.Actions
{
    public class EmployeeService : IEmployeeService
    {
        public Child Add(string email, Child child)
        {
            throw new NotImplementedException();
        }

        public Notification Bad(string email, string whoami)
        {
            throw new NotImplementedException();
        }

        public Child[] Children(string email)
        {
            throw new NotImplementedException();
        }

        public Employee Confirm(string email, string code)
        {
            throw new NotImplementedException();
        }

        public Employee OverRide(Employee obj)
        {
            throw new NotImplementedException();
        }

        public Notification Notify(string email, string message, Child[] children)
        {
            throw new NotImplementedException();
        }

        public Employee[] Others(string email)
        {
            throw new NotImplementedException();
        }

        public Notification Read(string email, string whoami)
        {
            throw new NotImplementedException();
        }

        public Handshake Register(string caretaker, string email, Child[] children)
        {
            throw new NotImplementedException();
        }

        public void Remove(string email, Child child)
        {
            throw new NotImplementedException();
        }

        public Notification Reply(string email, string message, string whoami)
        {
            throw new NotImplementedException();
        }

        public Notification Retract(string email, string whoami)
        {
            throw new NotImplementedException();
        }

        public Notification[] Stream(string email, int skip, int take)
        {
            throw new NotImplementedException();
        }

        Employee IEmployeeService.Confirm(string email, string code)
        {
            throw new NotImplementedException();
        }

        Employee IEmployeeService.Edit(Employee obj)
        {
            throw new NotImplementedException();
        }

        Notification IEmployeeService.Notify(string email, string message, Child[] children)
        {
            throw new NotImplementedException();
        }

        Notification IEmployeeService.Reply(string email, string message, string whoami)
        {
            throw new NotImplementedException();
        }

        Notification IEmployeeService.Retract(string email, string whoami)
        {
            throw new NotImplementedException();
        }

        Notification[] IEmployeeService.Stream(string email, int skip, int take)
        {
            throw new NotImplementedException();
        }

        Notification IEmployeeService.Read(string email, string whoami)
        {
            throw new NotImplementedException();
        }

        Handshake IEmployeeService.Register(string caretaker, string email, Child[] children)
        {
            throw new NotImplementedException();
        }

        Notification IEmployeeService.Bad(string email, string whoami)
        {
            throw new NotImplementedException();
        }

        Child IEmployeeService.Add(string email, Child child)
        {
            throw new NotImplementedException();
        }

        void IEmployeeService.Remove(string email, Child child)
        {
            throw new NotImplementedException();
        }

        Child[] IEmployeeService.Children(string email)
        {
            throw new NotImplementedException();
        }

        Employee[] IEmployeeService.Others(string email)
        {
            throw new NotImplementedException();
        }
    }
}