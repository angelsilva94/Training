import { HttpAngular2Page } from './app.po';

describe('http-angular2 App', () => {
  let page: HttpAngular2Page;

  beforeEach(() => {
    page = new HttpAngular2Page();
  });

  it('should display welcome message', done => {
    page.navigateTo();
    page.getParagraphText()
      .then(msg => expect(msg).toEqual('Welcome to app!!'))
      .then(done, done.fail);
  });
});
