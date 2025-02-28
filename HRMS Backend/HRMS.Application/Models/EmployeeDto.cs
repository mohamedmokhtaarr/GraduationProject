﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Application.Models
{
    public class EmployeeDto
    {
        [Required(ErrorMessage = "field is requird")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "field is requird")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "field is requird")]
        public string Address { get; set; }
        [Required]
        [Phone]
        [MinLength(11, ErrorMessage = "pls enter 11 number")]
        public string Phone { get; set; }
        public char Gender { get; set; }
        [Required(ErrorMessage = "field is requird")]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "1/1/1920", "1/1/2003", ErrorMessage = "Please enter a valid birth date (or) the employee must be at least 20 years old")]
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }
        [Required(ErrorMessage = "field is requird")]
        [MinLength(14, ErrorMessage = "pls enter 14 number ")]
        public string NationalId { get; set; }
        [Range(typeof(DateTime), "1/1/2008", "1/1/2023", ErrorMessage = "Date must be on or after 1/1/2008")]
        public DateTime HireDate { get; set; }
        [Required(ErrorMessage = ("pls enter a salary requird with vailed correct salary "))]
        [Column(TypeName = "money")]
        public decimal Salary { get; set; }
        [DataType(DataType.Time)]
        public DateTime ArrivalTime { get; set; }
        [DataType(DataType.Time)]
        public DateTime LeaveTime { get; set; }
    }
}

