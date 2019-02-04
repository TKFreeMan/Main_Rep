using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OneNineProject.Models
{
    public class Doc
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //Номер бумаги, он же Id этой бумаги
        [Key]
        public int DocId { get; set; }

        //Гриф секретности
        public string Seсrecy { get; set; }

        //Дата регистрации документа
        public DateTime DocDate { get; set; }

        //Дата получения документа
        public DateTime ReceiveDate { get; set; }
        
        //Подразделение (реализовано как один-ко-многим)
        public string Unit { get; set; }

        //Сотрудники для которых нужно выполнить работы
        public ICollection<Person> Persons { get; set; }

        //Тип работ
        public string WorkTypes { get; set; }

        //Исполнители работ
        public ICollection<Executor> Executors { get; set; }

        //Метки о выполнении
        public string CheckMarks { get; set; }

        //Примичания
        public string Notes { get; set; }

        //Статус зявки (Выполнена или нет)
        public bool Status { get; set; }
    }
}