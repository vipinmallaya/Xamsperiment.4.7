﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.XPath;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;
using Xamsperiment.View;

namespace Xamsperiment.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public Command MultiBindingCommand => new Command(MultiBindingAction);
        public Command ShapesCommand => new Command(ShapesAction);
        public Command AppThemeCommand => new Command(AppThemeAction);
        public Command ShapesAnimationCommand => new Command(ShapesAnimationAction);
        public Command GenerateBarcodeCommand => new Command(GenerateBarcodeAction);
        public Command TemplateCommand => new Command(TemplateAction);
        public Command BindingLibraryInvokeCommand => new Command(BindingLibraryInvokeAction);
        public Command BehaviourCommand => new Command(BehaviourAction);

        private async void BehaviourAction(object obj)
        {
            await NavigationPage.PushAsync(new BehaviourPage());
        }

        private void BindingLibraryInvokeAction(object obj)
        {
            var textAnalyzer = DependencyService.Get<ITextAnalyserHelper>();
                
            VowelsCount = textAnalyzer.NumVowels("SampleTest");
        }

        private string currentTIme;

        public string CurrentTime
        {
            get => currentTIme;
            set => OnPropertyChanged(ref currentTIme, value, nameof(CurrentTime));
        }

        private int vowelsCount;
        public int VowelsCount
        {
            get => vowelsCount;
            set => OnPropertyChanged(ref vowelsCount, value, nameof(VowelsCount));
        }

        private int consonentCount;
        public int ConsonentCount
        {
            get => consonentCount;
            set => OnPropertyChanged(ref vowelsCount, value, nameof(ConsonentCount));
        }
        private void TemplateAction(object obj)
        {
            NavigationPage.PushAsync(new TemplateSelector());
        } 

        private NavigationPage NavigationPage
        {
            get
            {
                return App.Current.MainPage as NavigationPage;
            }
        }

        private async void AppThemeAction(object obj)
        {
            await NavigationPage.PushAsync(new AppThemePage());
        }

        private async void MultiBindingAction(object obj)
        {
            await NavigationPage.PushAsync(new MultiBindingPage());
        }

        private async void ShapesAction(object obj)
        {
            await (App.Current.MainPage as NavigationPage).PushAsync(new ShapesPage());
        }

        private async void ShapesAnimationAction(object obj)
        {
            await (App.Current.MainPage as NavigationPage).PushAsync(new ShapesAnimationPage());
        }

        private async void GenerateBarcodeAction(object obj)
        {
            await (App.Current.MainPage as NavigationPage).PushAsync(new GenerateBarCodePage());
        }
    }
}
