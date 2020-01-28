using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Annotations;
using WeatherApp.Model;
using WeatherApp.ViewModel.Commands;
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
                       Value = "23"
                   }
               };
               this.  SelectedCity = new City()
               {
                   LocalizedName = "上海",
               };
                
            }

            SearchCommand = new SearchCommand(this);//初始化
            Cities = new ObservableCollection<City>();//初始化Cities
        }
        public ObservableCollection<City> Cities { get; set; }//类似angular 的BehaviorSubject

        public SearchCommand SearchCommand { get; set; }



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

        public City SelectedCity//我们在视图层绑定了SelectedCity，所以，视图上的SelectedValue发生变化，那么这里也发生变化，然后触发set中的方法。
        {
            get { return selectedCity; }
            set
            {
                selectedCity = value; 
                OnPropertyChanged(nameof(selectedCity));
                GetCurrentConditions();
            }
        }

        private async void GetCurrentConditions()
        {
            Query = string.Empty;
            Cities.Clear();
            CurrentConditions = await AccuWeatherHelper.GetCurrentCondition(SelectedCity.Key);
        }

        /// <summary>
        /// 这个方法将在Query属性发生变化的时候被调用 因此 需要实现ICommand接口
        /// </summary>
        public async void MakeQuery()
        {
          var citys = await   AccuWeatherHelper.GetCities(this.Query);
            Cities.Clear();
            citys.ForEach(x => 
            {
                Cities.Add(x);
            });
           
        }


    }
}
