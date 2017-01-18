

/// <remarks>
/// A namespace is to logically group together our classes.  Note,
/// that the namespace and the folder the class exists in do Not 
/// have to match or correspond.
/// </remarks>
namespace Prenotes.Services.Things
{
    /// <summary>
    /// Abstract user that is the base for Caretakers and 
    /// Employees making email the unique trait.
    /// </summary>
    /// <remarks>
    /// An abstract class is sort of inbetween an interface and 
    /// a regular class.  It is like an interface in that we 
    /// can provide methods that CAN be implemented but even 
    /// allows for properties to be sucked in by a class 
    /// that extends the abstraction.  Just like an interface it 
    /// can not be created as an object instance.  It is like a normal 
    /// class in that we can provide an default implementation 
    /// that may be overriden. 
    /// 
    /// https://msdn.microsoft.com/en-us/library/ms173150.aspx
    /// https://www.codeproject.com/Articles/6118/All-about-abstract-classes
    /// </remarks>
    public abstract class User {

        /// <summary>
        /// Unique identifier
        /// </summary>
        /// <remarks>
        /// When using readonly the property has to
        /// be set in the constructor (i.e. public User(...) {}). 
        /// The value of the property can not be changed 
        /// later on.  All of the properties in this class 
        /// are readonly making the class effectively "immutable" 
        /// (i.e. nothing can be edited or modified).
        /// 
        /// http://www.c-sharpcorner.com/UploadFile/c210df/difference-between-const-readonly-and-static-readonly-in-C-Sharp/
        /// </remarks>
        public readonly string email;

        /// <summary>
        /// Unix epoch when the User was registered
        /// </summary> 
        /// <remark>
        /// The long type is just a big integer (64 bits).  C# has 
        /// many different sizes for numbers: byte (only 8 bits), small integer (16 bits), 
        /// regular integer or int (32 bits), and long (64 bits).  The reason 
        /// for breaking out a number into different sizes is for saving memory.
        /// Every memroy allocation or copy costs CPU time.  The smaller the footprint 
        /// the fast stuff usually goes.  Long just like integer, string, and boolean are 
        /// primative types or what are known as value types (i.e. not an object).
        /// 
        /// The created property here houses an Unix epoch which is just 
        /// a duration from the 70s.  That duration can be transformed into 
        /// a date when we present it to the user in the client (JavaScript).
        /// </remark>
        public readonly long created;

        /// <summary>
        /// Forname, middle and last names exist in 
        /// the same field delimited by spaces.  Only one
        /// placeholder is automatically the last name.  Two
        /// placeholders the first is the first name and the 
        /// second the last name.  Two or more those between
        /// the first and last are considered middle names.
        ///
        /// The name is optional.
        /// </summary>
        public readonly string name;

        /// <remark>
        /// This is the constructor.  We use it to create instances. 
        /// Odd maybe that an abstract class which is never meant to 
        /// be an instance has a constructor.  But the idea is that 
        /// other classes which extend this can "reuse" the constructor 
        /// with the ": base(...)" directive.
        /// 
        /// https://msdn.microsoft.com/en-us/library/ms173115.aspx
        /// </remark>
        /// <param name="email"></param>
        /// <param name="created"></param>
        /// <param name="name"></param>
        public User (string email, long created, string name) {
            this.email = email;
            this.created = created;
            this.name = name;
        }

        /// <summary>
        /// Additional constructor nice for confirming users
        /// where the only important thing is that the email
        /// is correct.
        /// </summary>
        /// <param name="email"></param>
        public User (string email) {
            this.email = email;
            this.created = 0;
            this.name = null;
        }
    }
}