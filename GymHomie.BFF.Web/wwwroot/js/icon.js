export class Icon {
    constructor(element) {
        this.element = element;
    }

    async insertSvg(url) {
        if (!this.element) {
            console.error('There is no html element');
            return;
        }

        try {
            const response = await fetch(url);
            if (!response.ok) {
                throw new Error(`Can't load file ${url}`);
            }

            const svgText = await response.text();

            const parser = new DOMParser();
            const doc = parser.parseFromString(svgText, 'image/svg+xml');
            const svgElement = doc.querySelector('svg');

            if (!svgElement)
                throw new Error(`Invalid icon ${url}`);

            this.element.innerHTML = '';
            this.element.appendChild(svgElement);
        } catch (error) {
            console.error(error);
        }
    }
}