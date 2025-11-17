import { OmniSuiteTemplatePage } from './app.po';

describe('OmniSuite App', function () {
    let page: OmniSuiteTemplatePage;

    beforeEach(() => {
        page = new OmniSuiteTemplatePage();
    });

    it('should display message saying app works', () => {
        page.navigateTo();
        expect(page.getParagraphText()).toEqual('app works!');
    });
});
