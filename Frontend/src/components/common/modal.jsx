import React from "react";
import { withRouter } from "react-router-dom";

import { Modal, ModalHeader, ModalBody, ModalFooter } from "reactstrap";

class MyModal extends React.Component {
  render() {
    return (
      <div>
        <span
          onClick={this.props.toggle}
          className={"btn btn-link btn-" + this.props.color}
        >
          <i className={this.props.icon} /> {this.props.buttonLabel}
        </span>
        <Modal
          isOpen={this.props.modal}
          toggle={this.props.toggle}
          className={this.props.className}
        >
          <ModalHeader toggle={this.props.toggle}>
            {this.props.title}
          </ModalHeader>
          <ModalBody>{this.props.content}</ModalBody>
          <ModalFooter></ModalFooter>
        </Modal>
      </div>
    );
  }
}

export default withRouter(MyModal);
