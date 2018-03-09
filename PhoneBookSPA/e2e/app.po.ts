import { browser, by, element } from 'protractor';

export class AppPage {
  navigateTo() {
    return browser.get('/');
  }

  getTitleText(){
    return element(by.css('app-root a')).getText();
  }

  getIndexText() {
    return element(by.css('app-index h5')).getText();
  }

  getPageTitle(){
    return element(by.css('h5')).getText();
  }

  navigateToCreatePage(){
    return browser.get('/addContact');
  }

  clickCreateContact(){
    return element(by.className('nav-link')).click();
  }

  navigateToDetailsPage(){
    return browser.get('/contactDetails/id');
  }

  navigateToEditPage(){
    return browser.get('/editContact/id');
  }
}


