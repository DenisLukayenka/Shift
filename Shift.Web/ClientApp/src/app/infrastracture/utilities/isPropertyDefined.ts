import * as _ from 'lodash';

export const isPropertyDefined = (value: any, key: any) => !_.isUndefined(value) && !_.isNull(value);