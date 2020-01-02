using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Annotations;

namespace WeatherApp.ViewModel
{
  public  class WeatherVM : INotifyPropertyChanged
    {

        private int query;

        public int Query
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
    }
}
