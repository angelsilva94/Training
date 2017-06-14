import { ComplexFormsPage } from './app.po';

describe('complex-forms App', () => {
  let page: ComplexFormsPage;

  beforeEach(() => {
    page = new ComplexFormsPage();
  });

  it('should display welcome message', done => {
    page.navigateTo();
    page.getParagraphText()
      .then(msg => expect(msg).toEqual('Welcome to app!!'))
      .then(done, done.fail);
  });
});
