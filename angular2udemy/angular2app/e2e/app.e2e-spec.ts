import { Angular2appPage } from './app.po';

describe('angular2app App', () => {
  let page: Angular2appPage;

  beforeEach(() => {
    page = new Angular2appPage();
  });

  it('should display welcome message', done => {
    page.navigateTo();
    page.getParagraphText()
      .then(msg => expect(msg).toEqual('Welcome to app!!'))
      .then(done, done.fail);
  });
});
