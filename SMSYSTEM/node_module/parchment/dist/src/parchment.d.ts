import { Blot } from './blot/abstract/blot';
import ContainerBlot from './blot/abstract/container';
import FormatBlot from './blot/abstract/format';
import LeafBlot from './blot/abstract/leaf';
import ScrollBlot from './blot/scroll';
import InlineBlot from './blot/inline';
import BlockBlot from './blot/block';
import EmbedBlot from './blot/embed';
import TextBlot from './blot/text';
import Attributor from './attributor/attributor';
import ClassAttributor from './attributor/class';
import StyleAttributor from './attributor/style';
import AttributorStore from './attributor/store';
import * as Registry from './registry';
declare let Parchment: {
    Scope: typeof Registry.Scope;
    create: (input: string | Node | Registry.Scope, value?: any) => Blot;
    find: (node: Node, bubble?: boolean) => Blot;
    query: (query: string | Node | Registry.Scope, scope?: Registry.Scope) => Attributor | Registry.BlotConstructor;
    register: (...Definitions: any[]) => any;
    Container: typeof ContainerBlot;
    Format: typeof FormatBlot;
    Leaf: typeof LeafBlot;
    Embed: typeof EmbedBlot;
    Scroll: typeof ScrollBlot;
    Block: typeof BlockBlot;
    Inline: typeof InlineBlot;
    Text: typeof TextBlot;
    Attributor: {
        Attribute: typeof Attributor;
        Class: typeof ClassAttributor;
        Style: typeof StyleAttributor;
        Store: typeof AttributorStore;
    };
};
export default Parchment;
