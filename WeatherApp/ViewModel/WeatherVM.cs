using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Annotations;
using WeatherApp.Model;
using WeatherApp.ViewModel.Helpers;

namespace WeatherApp.ViewModel
{
  public  class WeatherVM : INotifyPropertyChanged
    {

        public WeatherVM()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {

               this.CurrentConditions = new CurrentConditions {WeatherText = "多云"};
               this. CurrentConditions.Temperature = new Temperature()
               {
                   Metric = new Units()
                   {
                       Value = 23
                   }
               };
               this.  SelectedCity = new City()
               {
                   LocalizedName = "上海",
               };
                
            }
        }

        private string query;

        public string Query
        {
            get { return query; }
            set
            {
                query = value; //当set的时候，就是属性值被改变的时候，因此在这里调用OnPropertyChanged方法
                OnPropertyChanged(nameof(Query));//该方法需要传入string类型属性名

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private CurrentConditions currentConditions;

        public CurrentConditions CurrentConditions
        {
            get => currentConditions;
            set
            {
                currentConditions
                    = value;
                OnPropertyChanged(nameof(CurrentConditions));
            }
               
        }


        private City selectedCity;

        public City SelectedCity
        {
            get { return selectedCity; }
            set
            {
                selectedCity = value; 
                OnPropertyChanged(nameof(selectedCity));
            }
        }

        /// <summary>
        /// 这个方法将在Query属性发生变化的时候被调用 因此 需要实现ICommand接口
        /// </summary>
        public async void MakeQuery()
        {
          var citys = await   AccuWeatherHelper.GetCities(this.Query);
        }


    }
}
