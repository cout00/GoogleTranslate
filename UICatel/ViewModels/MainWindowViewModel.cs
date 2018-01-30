using System.Data.Entity;
using System.Linq;
using Catel.Services;
using FTranslate.Core.BaseClasses;
using FTranslate.Core.ObjectPool;
using UICatel.Models;

namespace UICatel.ViewModels
{
    using Catel.MVVM;
    using System.Threading.Tasks;

    public class MainWindowViewModel :ViewModelBase
    {
        public MainWindowViewModel()
        {
                
        }

        //public override string Title { get { return "UICatel"; } }

        // TODO: Register models with the vmpropmodel codesnippet
        // TODO: Register view model properties with the vmprop or vmpropviewmodeltomodel codesnippets
        // TODO: Register commands with the vmcommand or vmcommandwithcanexecute codesnippets

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();
            await Pool.ActivatePoolAsync(typeof(LanguageString));
            wordsEntities wordsEntities=new wordsEntities();
            wordsEntities.Words.Load();            
        }
        protected override async Task CloseAsync()
        {// TODO: unsubscribe from events here

            await base.CloseAsync();
        }
    }
}
