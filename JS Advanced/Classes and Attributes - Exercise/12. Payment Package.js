class PaymentPackage {
    constructor(name, value) {
      this.name = name;
      this.value = value;
      this.VAT = 20;      // Default value    
      this.active = true; // Default value
    }
  
    get name() {
      return this._name;
    }
  
    set name(newValue) {
      if (typeof newValue !== 'string') {
        throw new Error('Name must be a non-empty string');
      }
      if (newValue.length === 0) {
        throw new Error('Name must be a non-empty string');
      }
      this._name = newValue;
    }
  
    get value() {
      return this._value;
    }
  
    set value(newValue) {
      if (typeof newValue !== 'number') {
        throw new Error('Value must be a non-negative number');
      }
      if (newValue < 0) {
        throw new Error('Value must be a non-negative number');
      }
      this._value = newValue;
    }
  
    get VAT() {
      return this._VAT;
    }
  
    set VAT(newValue) {
      if (typeof newValue !== 'number') {
        throw new Error('VAT must be a non-negative number');
      }
      if (newValue < 0) {
        throw new Error('VAT must be a non-negative number');
      }
      this._VAT = newValue;
    }
  
    get active() {
      return this._active;
    }
  
    set active(newValue) {
      if (typeof newValue !== 'boolean') {
        throw new Error('Active status must be a boolean');
      }
      this._active = newValue;
    }
  
    toString() {
      const output = [
        `Package: ${this.name}` + (this.active === false ? ' (inactive)' : ''),
        `- Value (excl. VAT): ${this.value}`,
        `- Value (VAT ${this.VAT}%): ${this.value * (1 + this.VAT / 100)}`
      ];
      return output.join('\n');
    }
}

const {assert, expect} = require("chai").expect;

describe('Testing PaymentPackage class', () => {
    it('Testing create instance', () => {
        let obj = new PaymentPackage('Pesho', 2)
        assert.instanceOf(obj, PaymentPackage);
        assert.property(obj, 'name');
        assert.property(obj, 'value');
        assert.property(obj, 'VAT');
        assert.property(obj, 'active');
        assert.property(obj, 'toString');
        assert.equal(obj.name, 'Pesho');
        assert.equal(obj.value, 2);
        assert.equal(obj.VAT, 20);
        assert.equal(obj.active, true);
    });
 
    it('Throws error on create instance', () => {
        assert.throw(() => { new PaymentPackage() }, 'Name must be a non-empty string');
        assert.throw(() => { new PaymentPackage('') }, 'Name must be a non-empty string');
        assert.throw(() => { new PaymentPackage([]) }, 'Name must be a non-empty string');
        assert.throw(() => { new PaymentPackage(12, '34') }, 'Name must be a non-empty string');
        assert.throw(() => { new PaymentPackage(false, '34') }, 'Name must be a non-empty string');
        assert.throw(() => { new PaymentPackage('Pesho') }, 'Value must be a non-negative number');
        assert.throw(() => { new PaymentPackage('Pesho', -2) }, 'Value must be a non-negative number');
        assert.throw(() => { new PaymentPackage('Pesho', '-2') }, 'Value must be a non-negative number');
        assert.throw(() => { new PaymentPackage('Pesho', false) }, 'Value must be a non-negative number');
    });
 
    it('Testing get name', () => {
        let paymentPackage = new PaymentPackage('Pesho', 2)
        assert.equal(paymentPackage.name, 'Pesho');
    });
 
    it('Testing set name', () => {
        let paymentPackage = new PaymentPackage('Pesho', 2)
        paymentPackage.name = 'Gosho'
        assert.equal(paymentPackage.name, 'Gosho');
    });
 
    it('Throws error on set name', () => {
        let paymentPackage = new PaymentPackage('Pesho', 2)
        assert.throw(() => { paymentPackage.name = {}; }, 'Name must be a non-empty string');
        assert.throw(() => { paymentPackage.name = ''; }, 'Name must be a non-empty string');
        assert.throw(() => { paymentPackage.name = false; }, 'Name must be a non-empty string');
    });
 
    it('Testing get value', () => {
        let paymentPackage = new PaymentPackage('Pesho', 2)
        assert.equal(paymentPackage.value, 2);
    });
 
    it('Testing set value', () => {
        let obj = new PaymentPackage('Pesho', 0)
        assert.equal(obj.value, 0);
        obj.value = 5
        assert.equal(obj.value, 5);
    });
 
    it('Throws error on set value', () => {
        let obj = new PaymentPackage('Pesho', 2)
        assert.throw(() => { obj.value = -22; }, 'Value must be a non-negative number');
        assert.throw(() => { obj.value = ''; }, 'Value must be a non-negative number');
        assert.throw(() => { obj.value = 'abc'; }, 'Value must be a non-negative number');
    });
 
    it('Testing get VAT', () => {
        let obj = new PaymentPackage('Pesho', 2)
        assert.equal(obj.VAT, 20);
    });
 
    it('Testing set VAT', () => {
        let obj = new PaymentPackage('Pesho', 0)
        assert.equal(obj.VAT, 20);
        obj.VAT = 2;
        assert.equal(obj.VAT, 2);
    });
 
    it('Throws error on set VAT', () => {
        let obj = new PaymentPackage('Pesho', 2)
        assert.throw(() => { obj.VAT = -22; }, 'VAT must be a non-negative number');
        assert.throw(() => { obj.VAT = ''; }, 'VAT must be a non-negative number');
        assert.throw(() => { obj.VAT = 'abc'; }, 'VAT must be a non-negative number');
    });
 
    it('Testing get active', () => {
        let obj = new PaymentPackage('Pesho', 2)
        assert.equal(obj.active, true);
    });
 
    it('Testing set active', () => {
        let obj = new PaymentPackage('Pesho', 2)
        obj.active = false;
        assert.equal(obj.active, false);
        obj.active = true;
        assert.equal(obj.active, true);
    });
 
    it('Throws error on set active', () => {
        let obj = new PaymentPackage('Pesho', 2)
        assert.throw(() => { obj.active = null; }, 'Active status must be a boolean');
        assert.throw(() => { obj.active = ''; }, 'Active status must be a boolean');
        assert.throw(() => { obj.active = ['abc']; }, 'Active status must be a boolean');
    });
 
    it('Testing toString() method', () => {
        let obj = new PaymentPackage('Pesho', 2)
        assert.equal(obj.toString(), `Package: Pesho\n- Value (excl. VAT): 2\n- Value (VAT 20%): 2.4`);
        obj.active = false;
        assert.equal(obj.toString(), `Package: Pesho (inactive)\n- Value (excl. VAT): 2\n- Value (VAT 20%): 2.4`);
    });
});

  