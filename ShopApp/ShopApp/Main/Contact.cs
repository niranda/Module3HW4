namespace ShopApp.Main
{
    public class Contact
    {
        public Contact(string fullName, string phone, double age)
        {
            FullName = fullName;
            Phone = phone;
            Age = age;
        }

        public string FullName { get; set; }
        public string Phone { get; set; }
        public double Age { get; set; }
    }
}
