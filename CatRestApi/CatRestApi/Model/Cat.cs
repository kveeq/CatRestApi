namespace CatRestApi.Model
{
    public class Cat
    {
        public Cat()
        {
        }

        public Cat(string id,string name, string color, bool gender)
        {
            this.id = id;
            this.name = name;
            this.color = color;
            this.gender = gender;
        }

        public string id { get; set; }
        public string name { get; set; }
        public string color { get; set; }
        public bool gender { get; set; }
    }
}