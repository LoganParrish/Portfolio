using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// step 1: Import System.ComponentModel.DataAnnotations
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{

    //step 2: create a partial class for the class we're trying to be the validation class
    //step 3. Add the annotation for the metaDataType
    [MetadataType(typeof(ContactValidation))]
    public partial class Contact
    {
    }
    public class ContactValidation
    {
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required, EmailAddress]
        public string email { get; set; }
        [Required]
        public string phoneNum { get; set; }
        [Required]
        public string comment { get; set; }
    }
}