namespace noteTakingApp.Models
{
    public class Notes
    {
        //this is setting the title portion of our Notes model, it is a string
        //a question mark in this case means its nullable aka not required, we want the title to be required but not the details as sometimes it is not always needed
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }

        public string? Details { get; set; }

    }
}
