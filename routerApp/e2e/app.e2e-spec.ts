import { RouterAppPage } from './app.po';

describe('router-app App', () => {
  let page: RouterAppPage;

  beforeEach(() => {
    page = new RouterAppPage();
  });

  it('should display welcome message', done => {
    page.navigateTo();
    page.getParagraphText()
      .then(msg => expect(msg).toEqual('Welcome to app!!'))
      .then(done, done.fail);
  });
});
