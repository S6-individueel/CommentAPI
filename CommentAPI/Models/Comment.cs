using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommentAPI.Models
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required]
        public string UserComment { get; set; }
        [Required]
        public int Likes { get; set; }
    }
}
