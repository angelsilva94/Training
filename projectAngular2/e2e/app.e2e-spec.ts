import { ProjectAngular2Page } from './app.po';

describe('project-angular2 App', () => {
  let page: ProjectAngular2Page;

  beforeEach(() => {
    page = new ProjectAngular2Page();
  });

  it('should display welcome message', done => {
    page.navigateTo();
    page.getParagraphText()
      .then(msg => expect(msg).toEqual('Welcome to app!!'))
      .then(done, done.fail);
  });
});
