class ResizeService {
  constructor(decorate, wysiwygNode) {
    this.dir = {};
    this.height = null;
    this.width = null;
    this.pos = null;
    this.evGlobal = null;
    this.currentDOMELement = null;
    this.resizeFunction = null;
    this.deleteListenerFunction = null;
    this.isElementVision = false;
    this.decorate = null;
    this.wysiwygNode = wysiwygNode;
    if(decorate) {
      let div = document.createElement('div');
      div.style.position = 'relative';
      div.style.display = 'inline-block';
      div.classList.add('decorate_block');
      div.style.height = decorate.getAttribute('height') + 'px';
      div.style.width = decorate.getAttribute('width') + 'px';

      async function getCloneNode(node, parentNode) {
        let clone = await node.cloneNode();
        clone.setAttribute('width','');
        clone.setAttribute('height','');
        clone.style.width = '100%';
        clone.style.height = '100%';
        clone.style.pointerEvents = 'none';
        parentNode.appendChild(clone);
        return {parentNode, clone};
      }
      
      getCloneNode(decorate, div).then(newNode => {
        decorate.parentNode.insertBefore(newNode.parentNode, decorate);
        decorate.remove();
        this.DOMElement = newNode.parentNode;
        this.DOMElement.setAttribute('contentEditable', false);
        this.decorate = newNode.clone;
        this.isElementVision = true;
        this.remove = this.removeClickOtherBlock.bind(this);
        document.addEventListener('click', this.remove);
        this.resizable({});
      });
    }
    else {
      this.DOMElement = null;
    }
  }

  removeClickOtherBlock(e) {
    if(!e.target.closest('.decorate_block') && !this.isElementVision) {
      this.decorate.style.cssText = null;
      this.decorate.setAttribute('width',  this.DOMElement.style.width.substring(0, this.DOMElement.style.width.length - 2) );
      this.decorate.setAttribute('height', this.DOMElement.style.height.substring(0, this.DOMElement.style.height.length - 2) );

      this.DOMElement.parentNode.replaceChild(this.decorate, this.DOMElement);

      this.wysiwygNode.changeTextEditor();
      document.removeEventListener('click', this.remove);
    }
    this.isElementVision = false;
  }

  resizable(options) {   
    this.options = {};
    this.options.max = [400, 400];
    this.options.min = [50, 50];
    this.options.allow = "11111111".split("");
    
    let resizeCubsList = this.addResizeBlocks(this.DOMElement);
    let vm = this;
    resizeCubsList.forEach(el => {
      el.addEventListener( "mousedown", vm.resizeStart.bind(this));
    });

    this.DOMElement.min = this.options.min;
    this.DOMElement.max = this.options.max;
    this.DOMElement.allow = this.options.allow;
    this.DOMElement.pos = this.DOMElement.getBoundingClientRect();
  }

  resizeStart(ev) {
	  this.dir = this.direction( this.DOMElement, ev );
    this.evGlobal = ev;
    if ( this.DOMElement.allow[this.dir] == "0" ) return;

    this.pos = this.DOMElement.getBoundingClientRect();
    this.height = this.DOMElement.clientHeight;
    this.width = this.DOMElement.clientWidth;

    this.resizeFunction = this.resize.bind(this);
    this.deleteListenerFunction = this.deleteListeners.bind(this);
    document.addEventListener( "mousemove", this.resizeFunction);    
    document.addEventListener( "mouseup", this.deleteListenerFunction);
  };

  resize (e) {
    if(this.dir > 3) {
      var currentWidth = this.DOMElement.clientWidth;
      var currentHeight = this.DOMElement.clientHeight;
      var scale = currentWidth / currentHeight;
      var tempHeight = (e.clientY - this.pos.top);
      var tempWidth = tempHeight * scale;

      this.DOMElement.style.width = tempWidth + 'px';
      this.DOMElement.style.height = tempHeight + 'px';
    }

    if (this.dir == 0) {
      this.DOMElement.style.top = e.clientY - this.evGlobal.clientY + this.pos.top;
      this.DOMElement.style.height = (this.height + this.evGlobal.clientY - e.clientY) + 'px';
    }
    if (this.dir == 1) {
      this.DOMElement.style.height = this.height + 'px';
      this.DOMElement.style.width = (e.clientX - this.pos.left) + 'px';
    }
    if (this.dir == 2) {
      this.DOMElement.style.height = (e.clientY - this.pos.top) + 'px';
    }
    if (this.dir == 3) {
      this.DOMElement.style.left = e.clientX - this.evGlobal.clientX + this.pos.left;
      this.DOMElement.style.width = (this.width + this.evGlobal.clientX - e.clientX) + 'px';
    }  
  }

  deleteListeners() {
    this.isElementVision = false;
    if(this.wysiwygNode.editor.clientWidth < this.DOMElement.clientWidth) {
      this.DOMElement.style.width = (this.wysiwygNode.editor.clientWidth - 20) + 'px';
    }

    this.wysiwygNode.changeTextEditor();


    document.removeEventListener( "mousemove", this.resizeFunction);
    document.removeEventListener( "mouseup", this.deleteListenerFunction);
  }

  direction(elem, event, pad) {
    let res = -1;

    let isTop = event.target.classList.contains('resize-top');
    let isRight = event.target.classList.contains('resize-right');
    let isBottom = event.target.classList.contains('resize-bottom');
    let isLeft = event.target.classList.contains('resize-left');
    let isRightBottom = event.target.classList.contains('resize-bottom_right');

    if ( isTop ) res = 0;
    if ( isRight ) res = 1;
    if ( isBottom ) res = 2;
    if ( isLeft ) res = 3;
    if ( isRightBottom ) res = 5;
    
    return res;
  }

  addResizeBlocks(elem) {

    let divLeft = document.createElement('div');
    divLeft.style.position = 'absolute';
    divLeft.style.border = '2px solid black';
    divLeft.style.background = '#FFF';
    divLeft.style.width ='10px';
    divLeft.style.height = '10px';
    divLeft.style.zIndex = 10000;
    divLeft.style.bottom = '50%';
    divLeft.style.left = '-5px';
    divLeft.style.cursor = 'e-resize';
    divLeft.classList.add('resize','resize-left');
    divLeft.setAttribute('contentEditable', false);
    elem.appendChild(divLeft);

    let divRight = document.createElement('div');
    divRight.style.position = 'absolute';
    divRight.style.border = '2px solid black';
    divRight.style.background = '#FFF';
    divRight.style.width ='10px';
    divRight.style.height = '10px';
    divRight.style.zIndex = 10000;
    divRight.style.bottom = '50%';
    divRight.style.right = '-5px';
    divRight.style.cursor = 'w-resize';
    divRight.classList.add('resize','resize-right');
    divRight.setAttribute('contentEditable', false);
    elem.appendChild(divRight);

    let divTop = document.createElement('div');
    divTop.style.position = 'absolute';
    divTop.style.border = '2px solid black';
    divTop.style.background = '#FFF';
    divTop.style.width ='10px';
    divTop.style.height = '10px';
    divTop.style.zIndex = 10000;
    divTop.style.top = '-5px';
    divTop.style.right = '50%';
    divTop.style.cursor = 'n-resize';
    divTop.classList.add('resize','resize-top');
    divTop.setAttribute('contentEditable', false);
    elem.appendChild(divTop);

    let divBottom = document.createElement('div');
    divBottom.style.position = 'absolute';
    divBottom.style.border = '2px solid black';
    divBottom.style.background = '#FFF';
    divBottom.style.width ='10px';
    divBottom.style.height = '10px';
    divBottom.style.zIndex = 10000;
    divBottom.style.bottom = '-5px';
    divBottom.style.right = '50%';
    divBottom.style.cursor = 's-resize';
    divBottom.classList.add('resize','resize-bottom');
    divBottom.setAttribute('contentEditable', false);
    elem.appendChild(divBottom);

    let divBottomRight = document.createElement('div');
    divBottomRight.style.position = 'absolute';
    divBottomRight.style.border = '2px solid black';
    divBottomRight.style.background = '#FFF';
    divBottomRight.style.width ='10px';
    divBottomRight.style.height = '10px';
    divBottomRight.style.zIndex = 10000;
    divBottomRight.style.bottom = '-5px';
    divBottomRight.style.right = '-5px';
    divBottomRight.style.cursor = 'se-resize';
    divBottomRight.classList.add('resize','resize-bottom_right');
    divBottomRight.setAttribute('contentEditable', false);
    elem.appendChild(divBottomRight);

    return [divLeft, divRight, divTop, divBottom, divBottomRight];
  }
}

export default ResizeService;