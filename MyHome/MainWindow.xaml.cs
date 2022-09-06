using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace MyHome
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            log.Click += Log_Click;
            //WinHelper.BlurOn(asas);

        }

        private void Log_Click(object sender, RoutedEventArgs e)
        {
           
        }

       

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          
        }











    }
    public static partial class WinHelper
    {
        /// <summary>Включение эффекта замыливания для <see cref="UIElement"/>.</summary>
        /// <param name="element">Окно или объект окна, к которому нужно применить эффект.</param>
        public static void BlurOn(this UIElement element, double radius = 5)
        {
            // Применение эффекта к элементу.
            element.SetCurrentValue(UIElement.EffectProperty, new BlurEffect() { Radius = radius });

            // Настройка прозрачности элемента.
            element.SetCurrentValue(UIElement.OpacityProperty, 0.87);
        }

        /// <summary>Отключение эффекта замыливания для <see cref="UIElement"/>.</summary>
        /// <param name="dObj">Окно или объект окна, у которого нужно отменить эффект.</param>
        public static void BlurOff(this UIElement element)
        {
            // Возвращение эффекта к прежнему значению.
            element.InvalidateProperty(UIElement.EffectProperty);

            // Возвращение прозрачности к прежнему значению.
            element.InvalidateProperty(UIElement.OpacityProperty);

        }

        /// <summary>Включение эффекта замыливания для окна.</summary>
        /// <param name="dObj">Окно или объект окна, к которому нужно применить эффект.</param>
        public static void WindowBlurOn(this DependencyObject dObj, double radius = 5)
        {
            // Поиск текущего окна.
            Window wind = Window.GetWindow(dObj); // GetAncestor<Window>(dObj);

            // Проверка на захват окна.
            if (wind == null)       //если окна нет,
                return;             //то выход из метода.

            // Применение эффекта к окну.
            wind.BlurOn(radius);
        }

        /// <summary>Отключение эффекта замыливания для окна.</summary>
        /// <param name="dObj">Окно или объект окна, у которого нужно отменить эффект.</param>
        public static void WindowBlurOff(this DependencyObject dObj)
        {
            // Поиск родителя текущего окна.
            Window wind = Window.GetWindow(dObj); // GetAncestor<Window>(dObj);

            // Проверка на захват окна.
            if (wind == null)       //если окна нет,
                return;             //то выход из метода.

            // Возвращение эффекта к прежнему значению.
            wind.BlurOff();
        }

        /// <summary>Метод замыливает <paramref name="element"/>,
        /// потом выполняет действие <paramref name="action"/>,
        /// после которого отключает эффект.</summary>
        /// <param name="element">Окно или объект окна, которое нужно замыливать во время исполнения действия <paramref name="action"/>.</param>
        /// <param name="action">Действие во время исполнения которого замыливается окно.</param>
        public static void BlurOnOff(this UIElement element, Action action, double radius = 5)
        {
            //Включение эффекта замыливания.
            element.BlurOn(radius);

            //Выполнение действия.
            action();

            //Отключение эффекта замыливания.
            element.BlurOff();
        }

        /// <summary>Метод замыливает <paramref name="element"/>,
        /// потом выполняет функцию <paramref name="func"/>,
        /// после чего отключает эффект и возвращает результат выполнения функции.</summary>
        /// <typeparam name="T">Тип результата, возвращаемого функцией.</typeparam>
        /// <param name="element">UI элемент, который нужно замыливать во
        /// время выполнения функции <paramref name="func"/>.</param>
        /// <param name="func">Функция во время выполнения которой замыливается окно.</param>
        /// <returns>Результат возвращённый <paramref name="func"/>.</returns>
        public static T BlurOnOff<T>(this UIElement element, Func<T> func, double radius = 5)
        {
            //Включение эффекта замыливания.
            element.BlurOn(radius);

            //Выполнение функции.
            T t = func();

            //Отключение эффекта замыливания.
            element.BlurOff();

            //Возвращение результата выполнения функции.
            return t;
        }

        /// <summary>Метод замыливает окно в котором находится <paramref name="dObj"/>,
        /// потом выполняет действие <paramref name="action"/>,
        /// после которого отключает эффект.</summary>
        /// <param name="dObj">Окно или объект окна, которое нужно замыливать
        /// во время исполнения действия <paramref name="action"/>.</param>
        /// <param name="action">Действие во время исполнения которого замыливается окно.</param>
        public static void WindowBlurOnOff(this DependencyObject dObj, Action action, double radius = 5)
        {
            //Включение эффекта замыливания.
            dObj.WindowBlurOn(radius);

            //Выполнение действия.
            action();

            //Отключение эффекта замыливания.
            dObj.WindowBlurOff();
        }

        /// <summary>Метод замыливает окно в котором находится <paramref name="dObj"/>,
        /// потом выполняет функцию <paramref name="func"/>,
        /// после чего отключает эффект и возвращает результат выполнения функции.</summary>
        /// <typeparam name="T">Тип результата, возвращаемого функцией.</typeparam>
        /// <param name="dObj">Окно или объект окна, которое нужно замыливать 
        /// во время выполнения функции <paramref name="func"/>.</param>
        /// <param name="func">Функция во время выполнения которой замыливается окно.</param>
        /// <returns>Результат возвращённый <paramref name="func"/>.</returns>
        public static T WindowBlurOnOff<T>(this DependencyObject dObj, Func<T> func, double radius = 5)
        {
            //Включение эффекта замыливания.
            dObj.WindowBlurOn(radius);

            //Выполнение функции.
            T t = func();

            //Отключение эффекта замыливания.
            dObj.WindowBlurOff();

            //Возвращение результата выполнения функции.
            return t;
        }
    }
}
