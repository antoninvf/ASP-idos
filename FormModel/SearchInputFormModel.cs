using System.ComponentModel.DataAnnotations;

namespace ASP_idos.FormModel;

public class SearchInputFormModel
{
    [Required]
    public string SearchInput { get; set; }
}