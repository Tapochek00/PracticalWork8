using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace PracticalWork8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            list.ItemsSource = currentValues;
        }

        ObservableCollection<PrimeNumbers> primeNumbers = new ObservableCollection<PrimeNumbers>();
        ObservableCollection<string> currentValues = new ObservableCollection<string>();
        private void btn_Next_Click(object sender, RoutedEventArgs e)
        {
            if (list.SelectedItem != null)
            {
                primeNumbers[list.SelectedIndex].GetNext();
                currentValues[list.SelectedIndex] = Convert.ToString(primeNumbers[list.SelectedIndex].Value);
            }
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (startValue.Text != null)
                {
                    int.TryParse(startValue.Text, out int start);
                    PrimeNumbers newNumber = new PrimeNumbers(start);
                    primeNumbers.Add(newNumber);
                    currentValues.Add(Convert.ToString(newNumber.Value));
                    startValue.Clear();
                }
                else
                {
                    PrimeNumbers newNumber = new PrimeNumbers();
                    primeNumbers.Add(newNumber);
                    currentValues.Add(Convert.ToString(newNumber.Value));
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_SetStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (list.SelectedItem != null)
                {
                    if (startValue.Text != "")
                    {
                        int.TryParse(startValue.Text, out int start);
                        primeNumbers[list.SelectedIndex].SetStart(start);
                        currentValues[list.SelectedIndex] = Convert.ToString(primeNumbers[list.SelectedIndex].Value);
                        startValue.Clear();
                    }
                    else
                    {
                        primeNumbers[list.SelectedIndex].SetStart();
                        currentValues[list.SelectedIndex] = Convert.ToString(primeNumbers[list.SelectedIndex].Value);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Compare_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id1, id2;
                id1 = list.Items.IndexOf(list.SelectedItems[0]);
                id2 = list.Items.IndexOf(list.SelectedItems[1]);
                if (primeNumbers[id1].CompareTo(primeNumbers[id2]) > 0) MessageBox.Show("Первое выделенное значение больше второго");
                else if (primeNumbers[id1].CompareTo(primeNumbers[id2]) < 0) MessageBox.Show("Первое выделенное значение меньше второго");
                else MessageBox.Show("Значения равны");
                list.SelectedItems.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Clone_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (list.SelectedItem != null)
                {
                    PrimeNumbers num = (PrimeNumbers)primeNumbers[list.SelectedIndex].Clone();
                    primeNumbers.Add(num);
                    currentValues.Add(Convert.ToString(num.Value));
                    list.SelectedItems.Clear();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            list.Items.Clear();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Дунаева М.И.\n\nПрактическая работа №8\n\n" +
                "Создать интерфейс – серия чисел (см. лекцию). Создать класс – простые числа." +
                "Класс должен включать конструктор. Сравнение производить по текущему значению.");
        }
    }
}
