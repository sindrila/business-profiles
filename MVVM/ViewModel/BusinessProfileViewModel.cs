﻿using bussiness_social_media.Core;
using bussiness_social_media.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using business_social_media.Services;

namespace bussiness_social_media.MVVM.ViewModel
{
    class BusinessProfileViewModel : Core.ViewModel
    {
        private INavigationService _navigation;
        private IBusinessService _businessService;
        private readonly AuthenticationService _authenticationService;
        private List<Post> _postList;
        private Business _currentBusiness;
        private bool _isCurrentUserManager;

        public bool IsCurrentUserManager
        {
            get
            {
                if (_authenticationService.getIsLoggedIn())
                {
                    return _businessService.IsUserManagerOfBusiness(CurrentBusiness.Id,
                        _authenticationService.CurrentUser.Username);
                }
                else
                {
                    return false;
                }
            }
            set
            {
                _isCurrentUserManager = value;
                OnPropertyChanged(nameof(IsCurrentUserManager));
            }
        }

        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }

        public Business CurrentBusiness 
        {

            get
            {
                return changeCurrrentBusiness();
            }
            set
            {
                _currentBusiness = value;
                OnPropertyChanged(nameof(CurrentBusiness)); 
            }
        }

        public RelayCommand NavigateToPostsCommand { get; set; }
        public RelayCommand NavigateToReviewsCommand { get; set; }
        public RelayCommand NavigateToContactCommand { get; set; }
        public RelayCommand NavigateToAboutCommand { get; set; }
        public BusinessProfileViewModel(INavigationService navigationService, IBusinessService businessService, AuthenticationService authenticationService)
        {
            Navigation = navigationService;
            _businessService = businessService;
            _authenticationService = authenticationService;
            NavigateToPostsCommand = new RelayCommand(o => { Navigation.NavigateTo<BusinessProfileViewModel>(); }, o => true);
            NavigateToReviewsCommand = new RelayCommand(o => { Navigation.NavigateTo<BusinessProfileReviewsViewModel>(); }, o => true);
            NavigateToContactCommand = new RelayCommand(o => { Navigation.NavigateTo<BusinessProfileContactViewModel>();  }, o => true);
            NavigateToAboutCommand =
                new RelayCommand(o => { Navigation.NavigateTo<BusinessProfileAboutViewModel>(); }, o => true);
            //_postList = _businessService.GetAllPostsOfBusiness(CurrentBusiness.Id);
            UpdatePostsCollection();
            changeCurrrentBusiness();
        }
        private ObservableCollection<Post> _posts;
        public ObservableCollection<Post> Posts
        {
            get => _posts;
            set
            {
                _posts = value;
                OnPropertyChanged();
            }
        }

        private void UpdatePostsCollection()
        {
            Posts = new ObservableCollection<Post>(_businessService.GetAllPostsOfBusiness(CurrentBusiness.Id));
        }

        public Business changeCurrrentBusiness()
        {
            return _businessService.GetBusinessById(_navigation.BusinessId);
        }

    }
}
