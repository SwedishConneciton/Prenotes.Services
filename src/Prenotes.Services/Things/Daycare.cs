
namespace Prenotes.Services.Things {

    public class Daycare {

        /// <summary>
        /// Unique identifier
        /// </summary>
        public readonly string name;

        /// <summary>
        /// When the daycare was registered
        /// </summary>
        public readonly int created;

        /// <summary>
        /// Employees
        /// </summary>
        public readonly Employee[] employees;

        /// <summary>
        /// Regulatory organization
        /// </summary>
        public readonly Organization regulatory;

        /// <summary>
        /// Full constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="created"></param>
        /// <param name="employees"></param>
        public Daycare(string name, int created, Employee[] employees, Organization regulatory) {
            this.name = name;
            this.created = created;
            this.employees = employees;
            this.regulatory = regulatory;
        }

        /// <summary>
        /// Name and regulatory organization ought to be provided
        /// </summary>
        /// <param name="name"></param>
        public Daycare(string name, Organization regulatory): this (name, 0, null, regulatory) {

        }
    }
}