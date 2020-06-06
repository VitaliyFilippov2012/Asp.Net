using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace PhoneDictionary
{
    [Serializable]
    [DataContract]
    [XmlRoot(ElementName = "phoneBook")]
    public class PhoneBook
    {
        public PhoneBook() { }

        [Key]
        [Required]
        [DataMember]
        [XmlElement(ElementName = "Id")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(30)]
        [DataMember]
        [XmlElement(ElementName = "Surname")]
        public string Surname { get; set; }

        [Required]
        [MaxLength(15)]
        [DataMember]
        [XmlElement(ElementName = "TelephoneNumber")]
        public string TelephoneNumber { get; set; }
    }
}