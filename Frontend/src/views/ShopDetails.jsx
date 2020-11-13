import React, { Component } from "react";
import MyModal from "./../components/common/modal.jsx";
import { Row } from "reactstrap";
import ShopForm from "./../components/shopForm";

class ShopDetails extends Component {
  state = {
    branches: [],
    employees: []
  };

  shopFormToggle = async () => {
    this.setState({ shopFormModal: !this.state.shopFormModal });
  };
  render() {
    const { shop } = this.props.location.state;
    return (
      <div className="content">
        <Row>
          <h2>{shop.name}</h2>
          <MyModal
            title="Shop Form"
            buttonLabel="Edit"
            color="warning"
            icon="fas fa-pen"
            content={
              <ShopForm
                shopId={shop.id}
                branches={this.state.branches}
                employees={this.state.employees}
                toggle={this.shopFormToggle}
              />
            }
            modal={this.state.shopFormModal}
            toggle={this.shopFormToggle}
          />
        </Row>
      </div>
    );
  }
}

export default ShopDetails;
