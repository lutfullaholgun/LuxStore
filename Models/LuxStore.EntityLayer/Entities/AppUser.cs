using LuxStore.EntityLayer.Interface;
using System.ComponentModel.DataAnnotations;

public class AppUser : IEntity
{
    public int Id { get; set; }

    [Display(Name = "Name")]
    public string Name { get; set; }

    [Display(Name = "Sur Name")]
    public string SurName { get; set; }

    [Display(Name = "Password")]
    public string Password { get; set; }

    [Display(Name = "Email")]
    public string Email { get; set; }

    [Display(Name = "Phone")]
    public string? Phone { get; set; }

    [Display(Name = "User Name")]
    public string? UserName { get; set; }

    [Display(Name = "Img")]
    public string? Image { get; set; }

    [Display(Name = "Is Active?")]
    public bool IsActive { get; set; }

    [Display(Name = "Is Admin?")]
    public bool IsAdmin { get; set; }

    [Display(Name = "Created Date")]
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    [Display(Name = "User Guid")]
    public Guid? UserGuid { get; set; } = Guid.NewGuid(); // guid burda nullable olabilir. Guid tanımlamamızın sebebi ise, kullanıcıya bir token vermek istediğimizde, bu token'ın bir değeri olması gerekiyor. Eğer kullanıcıya token vermek istemiyorsak, bu alanı nullable yapabiliriz. Guid.NewGuid() ile de her kullanıcıya farklı bir token vermiş oluyoruz.
}