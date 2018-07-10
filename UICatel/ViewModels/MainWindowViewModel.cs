using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using Catel.Data;
using Catel.Services;
using FTranslate.Core;
using FTranslate.Core.BaseClasses;
using FTranslate.Core.ObjectPool;
using FTranslate.Core.Yandex;
using UICatel.DataBase;
using UICatel.Views;
using Language = FTranslate.Core.BaseClasses.Language;

namespace UICatel.ViewModels
{
    using Catel.MVVM;
    using System.Threading.Tasks;
    public class MainWindowViewModel :ViewModelBase
    {

        //wordsEntities wordsEntities = new wordsEntities();
        DataBase.TranslatorEntity _translatorEntity=new TranslatorEntity();       
        public MainWindowViewModel()
        {
            LanguageCollectionTarget =new ObservableCollection<object>(Pool.GetByParentClass(typeof(Language)));
            LanguageCollection = new ObservableCollection<object>(Pool.GetByParentClass(typeof(Language)));
            SelectedLangMain = Pool.SingletonPool.GetPoolObject("Russian");
            SelectedLangTarget = Pool.SingletonPool.GetPoolObject("English");
            WindowsApiHelper.SetKeyBoardHook();
            WindowsApiHelper.OnKeyPush += WindowsApiHelper_OnKeyPush;
        }

        private void WindowsApiHelper_OnKeyPush(object sender, WindowsApiHelper.KeyPressedArgs e)
        {
            WindowsApiHelper.SendGetText();
            var dumpText = Clipboard.GetText();
            ((Language) SelectedLangMain).Text = dumpText;
            ((Language)(SelectedLangTarget)).Text= string.Empty;
            Parser pars =new YandexParser(new YandexHttpRequest(), (Language)SelectedLangMain, (Language)SelectedLangTarget);
            var resulteNotTranslatedException= pars.Translate();
            ResultString = ((Language) (SelectedLangTarget)).Text;
            //Words wordsMain=new Words() {Id_Language = (int)((Language)SelectedLangMain).Code};
            //Words wordsTarget = new Words() { Id_Language = (int)((Language)SelectedLangTarget).Code };

            //Session session=new Session() {};
            var newWordMain=_translatorEntity.Words.Add(new Words() {Date = (decimal?)DateTime.Now.ToOADate(), Word = "me"});
            var newWordTarget =_translatorEntity.Words.Add(new Words() { Date = (decimal?)DateTime.Now.ToOADate(), Word = "met" });
            _translatorEntity.Session.Add(new DbSession() {WordResult = newWordMain, WordTarget = newWordTarget});
            _translatorEntity.SaveChanges();
        }

        #region LanguageCollectionTarget property

        public ObservableCollection<object> LanguageCollectionTarget
        {
            get { return GetValue<ObservableCollection<object>>(LanguageCollectionTargetProperty); }
            set { SetValue(LanguageCollectionTargetProperty, value); }
        }



        public static readonly PropertyData LanguageCollectionTargetProperty = RegisterProperty("LanguageCollectionTarget", typeof(ObservableCollection<object>));

        #endregion


        #region ResultString property

        public string ResultString
        {
            get { return GetValue<string>(ResultStringProperty); }
            set { SetValue(ResultStringProperty, value); }
        }

        public static readonly PropertyData ResultStringProperty = RegisterProperty("ResultString", typeof(string));

        #endregion



        #region SelectedLangMain property

        public object SelectedLangMain
        {
            get { return GetValue<object>(SelectedLangMainProperty); }
            set { SetValue(SelectedLangMainProperty, value); }
        }

        public static readonly PropertyData SelectedLangMainProperty = RegisterProperty("SelectedLangMain", typeof(object));

        #endregion


        #region SelectedLangTarget property

        public object SelectedLangTarget
        {
            get { return GetValue<object>(SelectedLangTargetProperty); }
            set { SetValue(SelectedLangTargetProperty, value); }
        }

        public static readonly PropertyData SelectedLangTargetProperty = RegisterProperty("SelectedLangTarget", typeof(object));

        #endregion




        #region LanguageCollection property

        public ObservableCollection<object> LanguageCollection
        {
            get { return GetValue<ObservableCollection<object>>(LanguageCollectionProperty); }
            set { SetValue(LanguageCollectionProperty, value); }
        }

        public static readonly PropertyData LanguageCollectionProperty = RegisterProperty("LanguageCollection", typeof(ObservableCollection<object>));

        #endregion

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();
            await _translatorEntity.Words.LoadAsync();                                    
        }
        protected override async Task CloseAsync()
        {            
            WindowsApiHelper.RemoveKeyBoardHook();
            await base.CloseAsync();
        }
    }
}
