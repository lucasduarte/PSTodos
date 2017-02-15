import { PSTodosPage } from './app.po';

describe('pstodos App', function() {
  let page: PSTodosPage;

  beforeEach(() => {
    page = new PSTodosPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
