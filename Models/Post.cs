namespace Models
{
	public class Post : object
	{
		public Post() : base()
		{
		}

		// **********
		public int Id { get; set; }
		// **********

		// **********
		public bool IsActive { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Required]
		public string Body { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Required]
		public string Title { get; set; }
		// **********
	}
}
