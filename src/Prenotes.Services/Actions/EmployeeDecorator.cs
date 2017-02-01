using Prenotes.Services.Things;

namespace Prenotes.Services.Actions
{
    public abstract class EmployeeDecorator : IEmployeeService
    
    {

    protected readonly IEmployeeService srv;    

    public EmployeeDecorator (IEmployeeService srv) {
        this.srv =srv;        
    }
    
    public virtual Child Add(string email, Child child)
    {
        return this.srv.Add(email, child);
    }

    public virtual Notification Bad(string email, string whoami)
    {
        return this.srv.Bad(email, whoami);
    }

    public virtual Child[] Children(string email)
    {
        return this.srv.Children(email);
    }

    public virtual Employee Confirm(string email, string code)
    {
        return this.srv.Confirm(email, code);
    }

    public virtual Employee Edit(Employee obj)
    {
        return this.srv.Edit(obj);
    }

       public virtual Notification Notify(string email, string message, Child[] children)
        {
         return this.srv.Notify(email, message, children);

        }

       public virtual Employee[] Others(string email)
        {
            return this.srv.Others(email);
        }

       public virtual Notification Read(string email, string whoami)
        {
            return this.srv.Read(email, whoami);
        }

      public virtual  Handshake Register(string caretaker, string email, Child[] children)
        {
            return this.srv.Register(caretaker, email, children);
        }

       public virtual void Remove(string email, Child child)
        {
             this.srv.Remove(email, child);
        }

       public virtual Notification Reply(string email, string message, string whoami)
        {
            return this.srv.Reply(email, message, whoami);
        }

       public virtual Notification Retract(string email, string whoami)
        {
            return this.srv.Retract(email, whoami);
        }

       public virtual Notification[] Stream(string email, int skip, int take)
        {
            return this.srv.Stream(email, skip, take);
        }
    };
  



    // TODO: Mimic what was done with CaretakerDecorator

    // public abstract class ?? : IEmployeeService {

        // TODO: Need private readonly field for the underlying service (Hint: "protected readonly IEmployeeService srv;")

        // TODO: Add constructor that sets the underlying serivce (Hint: "public EmployeeDecorator (IEmployeeService srv) {...}")

        // TODO: Add default implementations for every method that is defined by IEmployeeService
        //       where the methods just hand off parameters to the same method in the underlying service.

    //}
}