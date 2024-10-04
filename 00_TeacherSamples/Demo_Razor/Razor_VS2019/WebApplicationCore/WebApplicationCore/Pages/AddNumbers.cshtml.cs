using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplicationCore.Pages
{
    public class AddNumbersModel : PageModel
    {
        private readonly Model.IOperator _service;

        public AddNumbersModel(Model.IOperator service)
        {
            _service = service;
        }

        //private readonly Model.Operation _service;
        //public AddNumbersModel(Model.Operation service)
        //{
        //    _service = service;
        //}

        public double FirstOperand { get; set; }
        public double SecondOperand { get; set; }
        public bool IsCorrect { get; set; } = true;

        public string Message { get; set; } = "Операция сложения";
        public string MessageRezult { get; set; }

        // GET-запрос (пример)
        // https://localhost:44374/AddNumbers?p1=2&p2=35
        public void OnGet(double p1, double p2)
        {
            //Model.Operation top = new Model.Operation();
            if (p1 < 1 || p2 > 110)
            {
                IsCorrect = false;
                return;
            }
            FirstOperand = p1;
            SecondOperand = p2;

          //  double result = top.Add(p1, p2);
            double result = _service.Add(p1, p2); // p1 + p2;
            MessageRezult = $"При сложении {p1} и {p2} получится {result.ToString("F2")}";
        }

        //public void OnGet()
        //{
        //    //   Message = "Метод get";
        //}

        public void OnPost(double p1, double p2)
        {
            if (p1 < 1 || p2 > 110)
            {
                MessageRezult = "Переданы некорректные данные. Повторите ввод";
            }
            else
            {
                double result = _service.Add(p1, p2); // p1 + p2;
                // ToString("F2") - форматирование числа: F2 - дробное число с 2 знаками после запятой
                MessageRezult = $"При сложении {p1} и {p2} получится {result.ToString("F2")}";
                FirstOperand = p1;
                SecondOperand = p2;
            }
        }


    }



}
