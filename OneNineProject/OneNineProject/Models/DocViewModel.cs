using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace OneNineProject.Models
{
    public class DocViewModel
    { 
        
        [Key]
        [Display(Name = "Document number:")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //Номер бумаги, он же Id этой бумаги
        public int DocId { get; set; }

        [Display(Name="Document secrecy:")]
        //Гриф секретности
        public string Seсrecy { get; set; }

        [Display(Name="Document registration date:")]
        //Дата регистрации документа
        public DateTime DocDate { get; set; }

        [Display(Name="Document receive date:")]
        //Дата получения документа
        public DateTime ReceiveDate { get; set; }

        [Display(Name="Customers unit:")]
        //Подразделение 
        public string Unit { get; set; }

        [Display(Name= "Employees(-yee):")]
        [DataType(DataType.MultilineText)]
        //Сотрудники для которых нужно выполнить работы
        public string Persons { get; set; }

        [Display(Name="Work type:")]
        [DataType(DataType.MultilineText)]
        //Тип работ
        public string WorkTypes { get; set; }

        [Display(Name="Executors:")]
        [DataType(DataType.MultilineText)]
        //Исполнители работ
        public string Executors { get; set; }

        [Display(Name="Check Marks:")]
        [DataType(DataType.MultilineText)]
        //Метки о выполнении
        public string CheckMarks { get; set; }

        [Display(Name="Notes:")]
        [DataType(DataType.MultilineText)]
        //Примичания
        public string Notes { get; set; }
        
        [Display(Name="Execution status")]
        //Статус зявки (Выполнена или нет)
        public bool Status { get; set; }
    }
}