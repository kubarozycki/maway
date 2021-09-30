import React from 'react';
import ReactDOM from 'react-dom';
const modalRoot = document.getElementById('modal-portal-root');

class ModalPortal extends React.Component {
  constructor(props) {
    super(props);
    this.el = document.createElement('div');
    this.el.className = 'modal-background';
  }

  componentDidMount() {
    modalRoot.appendChild(this.el);
  }

  componentWillUnmount() {
    modalRoot.removeChild(this.el);
  }

  render() {
    return ReactDOM.createPortal(
      this.props.children,
      this.el
    );
  }
}

export default ModalPortal;