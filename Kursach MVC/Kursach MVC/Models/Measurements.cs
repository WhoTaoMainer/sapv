using System.ComponentModel.DataAnnotations;

namespace Kursach_MVC.Models
{
    public class Measurements
    {
        [Display(Name = "Обхват груди")]
        [Required]
        [Range(76, 140, ErrorMessage = "Обхват груди должен быть от 76 до 140 см")]
        public int OG {  get; set; } //обхват груди
        [Display(Name = "Обхват талии")]
        [Range(58, 130, ErrorMessage = "Обхват талии должен быть от 58 до 130 см")]

        public int OT {  get; set; } //обхват талии
        [Display(Name = "Обхват бедер")]
        [Range(82, 150, ErrorMessage = "Обхват бедер должен быть от 82 до 150 см")]

        public int OB {  get; set; } // обхват бедер
        [Display(Name = "Высота бедер")]
        [Range(18, 26, ErrorMessage = "Высота бедер должна быть от 18 до 26 см")]

        public int VB {  get; set; } //высота бедер 
        [Display(Name = "Ширина спины")]
        [Range(25, 55, ErrorMessage = "Ширина спины должна быть от 25 до 55 см")]

        public int Shs {  get; set; } //ширина спины
        [Display(Name = "Ширина проймы")]
        [Range(8, 20, ErrorMessage = "Ширина проймы должна быть от 8 до 20 см")]

        public int ShPr {  get; set; } //ширина проймы
        [Display(Name = "Ширина груди 1")]
        [Range(35, 55, ErrorMessage = "Ширина груди 1 должна быть от 35 до 55 см")]

        public int ShG1 {  get; set; } //ширина груди 1
        [Display(Name = "Ширина груди 2")]
        [Range(30, 50, ErrorMessage = "Ширина груди 2 должна быть от 30 до 50 см")]

        public int ShG2 {  get; set; } //ширина руди 2
        [Display(Name = "Длина талии по спинке")]
        [Range(36, 50, ErrorMessage = "Длина талии по спинке должна быть от 36 до 50 см")]

        public int DTS {  get; set; } //длина до талии спинки
        [Display(Name = "Высота плеча косая")]
        [Range(36, 48, ErrorMessage = "Высота плеча косая должна быть от 36 до 48 см")]

        public int VPK {  get; set; } // высота плеча косая
        [Display(Name = "Длина талии переда")]
        [Range(36, 52, ErrorMessage = "Длина талии переда должна быть от 36 до 52 см")]

        public int DTP {  get; set; } // длина до талии переда
        [Display(Name = "Высота плеча косая переда")]
        [Range(36, 52, ErrorMessage = "Длина талии переда должна быть от 36 до 52 см")]

        public int VPKP {  get; set; } // высота плеча косая переда
        [Display(Name = "Длина плеча")]
        [Range(10, 17, ErrorMessage = "Длина плеча должна быть от 10 до 17 см")]

        public int DPl {  get; set; } // длина плеча
        [Display(Name = "Обхват шеи")]
        [Range(32, 50, ErrorMessage = "Обхват шеи должен быть от 32 до 50 см")]

        public int OSh {  get; set; } //обхват шеи
        [Display(Name = "Высота груди")]
        [Range(20, 34, ErrorMessage = "Высота груди должна быть от 20 до 34 см")]

        public int VG { get; set; } //высота груди
        [Display(Name = "Центр груди")]
        [Range(10, 30, ErrorMessage = "Центр груди должен быть от 10 до 30 см")]

        public int CG { get; set; } //центр груди
        [Display(Name = "Глубина проймы")]
        [Range(18, 28, ErrorMessage = "Глубина проймы должна быть от 18 до 28 см")]

        public int GPr { get; set; } //глубмна проймы
        [Display(Name = "Длина изделия")]
        [Range(70, 180, ErrorMessage = "Длина изделия должна быть от 70 до 180 см")]

        public int DI { get; set; } //длина изделия

    }
}
